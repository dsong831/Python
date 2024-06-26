from flask import Flask, render_template, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from flask_cors import CORS
from datetime import datetime
from functools import wraps

app = Flask(__name__)
CORS(app)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///tuning_center.db'
db = SQLAlchemy(app)

class Customer(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    name = db.Column(db.String(100), nullable=False)
    pianos = db.relationship('Piano', back_populates='customer')

class Piano(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    number = db.Column(db.String(100), nullable=False)
    customer_id = db.Column(db.Integer, db.ForeignKey('customer.id'), nullable=False)
    customer = db.relationship('Customer', back_populates='pianos')
    tuning_history = db.relationship('TuningHistory', back_populates='piano')

class TuningHistory(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date, nullable=False)
    comment = db.Column(db.String(200))
    piano_id = db.Column(db.Integer, db.ForeignKey('piano.id'), nullable=False)
    piano = db.relationship('Piano', back_populates='tuning_history')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/reservation')
def reservation():
    return render_template('reservation.html')

@app.route('/check-history', methods=['POST'])
def check_history():
    name = request.form['name']
    piano_number = request.form['piano_number']
    customer = Customer.query.filter_by(name=name).first()
    if customer:
        piano = Piano.query.filter_by(customer=customer, number=piano_number).first()
        if piano:
            tuning_history = TuningHistory.query.filter_by(piano=piano).order_by(TuningHistory.date.desc()).all()
            history_data = []
            for history in tuning_history:
                history_data.append({
                    'date': history.date.strftime('%Y-%m-%d'),
                    'comment': history.comment
                })
            return jsonify(history_data)
    return jsonify([])

@app.route('/create-reservation', methods=['POST'])
def create_reservation():
    name = request.form['name']
    phone = request.form['phone']
    location = request.form['location']
    payment = request.form['payment']
    piano_number = request.form['piano_number']
    reservation_comment = request.form['reservation_comment']

    customer = Customer.query.filter_by(name=name).first()
    if not customer:
        customer = Customer(name=name)
        db.session.add(customer)
        db.session.commit()

    piano = Piano.query.filter_by(customer=customer, number=piano_number).first()
    if not piano:
        piano = Piano(number=piano_number, customer=customer, customer_id=customer.id)
        db.session.add(piano)
        db.session.commit()

    existing_history = TuningHistory.query.filter_by(piano=piano, date=datetime.now().date(), comment=reservation_comment).first()
    if not existing_history:
        tuning_history = TuningHistory(date=datetime.now().date(), comment=reservation_comment, piano=piano)
        db.session.add(tuning_history)
        db.session.commit()

    return jsonify({'message': '예약이 완료되었습니다.'}), 200

@app.route('/get-reservations', methods=['GET'])
def get_reservations():
    reservations = []
    tuning_histories = TuningHistory.query.all()
    for history in tuning_histories:
        piano = history.piano
        customer = piano.customer
        reservation = {
            'name': customer.name,
            'piano_number': piano.number,
            'phone': customer.phone,
            'location': customer.location,
            'payment': customer.payment,
            'reservation_comment': history.comment,
            'reservation_date': history.date.strftime('%Y-%m-%d')
        }
        reservations.append(reservation)
    return jsonify(reservations)

@app.route('/admin')
def admin():
    return render_template('admin.html')

def admin_required(func):
    @wraps(func)
    def decorated_view(*args, **kwargs):
        if 'admin' not in session:
            return jsonify({'message': '관리자 권한이 필요합니다.'}), 403
        return func(*args, **kwargs)
    return decorated_view

@app.route('/delete-reservation', methods=['POST'])
@admin_required
def delete_reservation():
    reservation_id = request.form['reservation_id']
    tuning_history = TuningHistory.query.get(reservation_id)
    if tuning_history:
        db.session.delete(tuning_history)
        db.session.commit()
        return jsonify({'message': '예약이 삭제되었습니다.'}), 200
    return jsonify({'message': '해당 예약이 존재하지 않습니다.'}), 404

with app.app_context():
    db.create_all()

if __name__ == '__main__':
    app.run(debug=True)
