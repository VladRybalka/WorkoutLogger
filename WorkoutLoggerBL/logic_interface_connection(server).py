import flask as f
from Logic.Database_Logic import database_init

connect = f.Flask(__name__)

@connect.route('/start')
def test():
    database_init.init_database()
    return "200"

connect.run(port = 5001)