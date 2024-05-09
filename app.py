from flask import Flask, render_template, request, redirect, url_for

app = Flask(__name__)

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