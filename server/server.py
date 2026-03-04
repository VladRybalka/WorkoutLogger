import flask
import Logic.work_with_databases as wb

app = flask.Flask(__name__)

@app.route('/add_sport/<name>/<fields>')
def add_sport(name, fields):
    wb.add_sport(name, fields)
    return "200"

@app.route('/add_train/<year>/<sport>/<data>')
def add_train(year, sport, data):
    wb.add_train(year, sport, data)
    return "200"

@app.route('/get_train/<sport>/<year>/<month>/<day>')
def get_train(sport, year, month, day):
    wb.get_train(sport, year, month, day)
    return "200"

app.run(port=5000)