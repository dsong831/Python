from app import db

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