import flask as f
from Logic.Database_Logic.database_init import init_database

connect = f.Flask(__name__)

@connect.route('/start')
def test():
    init_database()
    return "200"

connect.run(port = 5001)