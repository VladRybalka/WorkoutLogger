import flask

app = flask.Flask(__name__)

@app.route('/add_sport')
def add_sport():
    pass

@app.route('/add_train')
def add_train():
    pass

@app.route('/get_train')
def get_train():
    pass

app.run(port=5000)