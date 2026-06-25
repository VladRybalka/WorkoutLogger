import flask as f
from Logic.Database_Logic import database_init, database_adding_data
import logs.logger as log

connect = f.Flask(__name__)

@connect.route('/start')
def start():
    log.info_message("Starting database initialization.")
    database_init.init_database()
    log.info_message_space('The database has been initialized.')
    return "200"

#region -==- ADD -==-

@connect.route('/add_sport')
def add_sport(name, characteristics):
    log.info_message_space("Start adding sports to the database.")
    database_adding_data.add_data_into_sport(name, characteristics)
    log.info_message_space('End adding sports to the database.')

@connect.route('/add_data')
def add_data():
    log.info_message_space("Adding data to the database.")

@connect.route('/add_column')
def add_column():
    log.info_message_space("Adding columns to the database.")

#endregion

connect.run(port = 5001)