from flask import Flask, render_template, request, jsonify
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
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

@app.route('/reset-history', methods=['POST'])
def reset_history():
    name = request.form['name']
    piano_number = request.form['piano_number']

    customer = Customer.query.filter_by(name=name).first()
    if customer:
        piano = Piano.query.filter_by(customer=customer, number=piano_number).first()
        if piano:
            TuningHistory.query.filter_by(piano=piano).delete()
            db.session.commit()
            return jsonify({'message': '기존 이력이 초기화되었습니다.'})

    return jsonify({'message': '해당 고객 또는 피아노를 찾을 수 없습니다.'})

if __name__ == '__main__':
    app.run(debug=True)