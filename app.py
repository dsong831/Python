from flask import Flask, render_template, request, redirect, url_for, jsonify
from models import Customer, Piano, TuningHistory

app = Flask(__name__)

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

@app.route('/')
def index():
    return render_template('index.html', image_file='static/piano.jpg')

@app.route('/reservation', methods=['GET', 'POST'])
def reservation():
    if request.method == 'POST':
        # Process reservation form data
        name = request.form['name']
        contact = request.form['contact']
        location = request.form['location']
        piano_number = request.form['piano_number']
        has_history = 'has_history' in request.form
        payment_method = request.form['payment_method']
        
        # TODO: Save reservation data to database
        
        return redirect(url_for('reservation_success'))
    
    return render_template('reservation.html')

@app.route('/reservation-success')
def reservation_success():
    # TODO: Display reservation confirmation
    return "Reservation successful!"

if __name__ == '__main__':
    app.run()