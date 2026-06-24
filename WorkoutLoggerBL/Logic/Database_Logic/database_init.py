import Logic.Database_Logic.database_create_table as dct
import logs.logger as log

def init_database():
    log.info_message("Sport table:")
    dct.create_sport_table()

    log.info_message_space("Workout table:")
    dct.create_workouts_table()