import flask as f
from Logic.Database_Logic import (database_init, database_adding_data, database_request_data,
                                  database_create_table)
import logs.logger as log

connect = f.Flask(__name__)

# Initialization database.
@connect.route('/start')
def start():
    log.info_message("Starting database initialization.")
    database_init.init_database()
    log.info_message_space('The database has been initialized.')
    return "200"

#region -==- ADD -==-

#region Sport

# Add sport in database(table: sport)
@connect.route('/add_sport/<name>/<characteristics>')
def add_sport(name, characteristics):
    log.info_message_space("Start adding sports to the database.")
    database_adding_data.add_data_into_sport(name, characteristics)
    database_create_table.create_workouts_table()
    log.info_message_space('End adding sports to the database.')
    return "200"

# Checking for sports availability in database(table: sport).
@connect.route('/check_sport_availability/<name>')
def check_sport_availability(name):
    res = "200"
    sports = database_request_data.get_all_sports_data()
    for sport in sports:
        if name.lower() == sport[0].lower():
            res = "409"    # Conflict
    return res

#endregion

#region Data

# Add data in database(table: Workout_?)
@connect.route('/add_data/<sport>/<characteristics>')
def add_data(sport, characteristics):
    pass

@connect.route('/get_sport')
def get_sport():
    log.info_message_space("Get sports names from database.")
    return f.jsonify([row[0] for row in database_request_data.get_all_sports_data()])

@connect.route('/get_characteristics/<sport>')
def get_characteristics(sport):
    log.info_message_space("Get sports characteristics from database.")
    data = database_request_data.get_sport_characteristics(sport)[0][0]
    data = data.split(';')
    characteristics = []
    for i in data:
        characteristics.append(i.split(':')[0])
    return f.jsonify(characteristics)

#endregion

#region Column

# Add column in database table(Workout_?)
@connect.route('/add_column')
def add_column():
    log.info_message_space("Adding columns to the database.")

#endregion

#endregion

connect.run(port = 5001)