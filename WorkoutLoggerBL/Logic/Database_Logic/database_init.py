import Logic.Database_Logic.database_create_table as dct

def init_database():
    dct.create_workouts_table()
    dct.create_sport_table()