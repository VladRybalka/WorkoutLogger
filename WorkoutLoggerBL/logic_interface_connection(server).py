import flask as f
from Logic.Database_Logic import database_init
import logs.logger as log

connect = f.Flask(__name__)

@connect.route('/start')
def start():
    log.info_message("Starting database initialization.")
    database_init.init_database()
    log.info_message_space('The database has been initialized.')
    return "200"

connect.run(port = 5001)