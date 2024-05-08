# app.py
from flask import Flask, render_template, request, jsonify
import requests

app = Flask(__name__)

# 메인 페이지
@app.route('/')
def index():
    return render_template('index.html')

# 예약 페이지
@app.route('/booking', methods=['GET', 'POST'])
def booking():
    if request.method == 'POST':
        # 예약 폼 데이터 받기
        customer_name = request.form['customer_name']
        phone = request.form['phone']
        location = request.form['location']
        piano_number = request.form['piano_number']
        has_history = True if request.form.get('has_history') else False
        payment_method = request.form['payment_method']

        # 예약 데이터를 백엔드 API로 전송
        booking_data = {
            'customer_name': customer_name,
            'phone': phone,
            'location': location,
            'piano_id': get_piano_id(piano_number), # 피아노 번호로 ID 조회
            'has_history': has_history,
            'payment_method': payment_method
        }
        response = requests.post('http://localhost:5000/api/bookings', json=booking_data)
        if response.status_code == 200:
            return render_template('booking_success.html')
        else:
            return render_template('booking_error.html'), response.status_code

    # 피아노 번호로 과거 예약 내역 조회
    piano_number = request.args.get('piano_number')
    if piano_number:
        bookings = get_bookings_by_piano(piano_number)
    else:
        bookings = []

    return render_template('booking.html', bookings=bookings)

# 피아노 번호로 ID 조회 (가정: 백엔드 API 호출)
def get_piano_id(piano_number):
    # ...
    return 123

# 피아노 번호로 과거 예약 내역 조회 (가정: 백엔드 API 호출)
def get_bookings_by_piano(piano_number):
    # ...
    return [
        {'created_at': '2023-05-01', 'work_description': '...'},
        {'created_at': '2022-11-15', 'work_description': '...'}
    ]

if __name__ == '__main__':
    app.run()