import Logic.Database_Logic.database_create_table as dct

def init_database():
    dct.create_sport_table()
    dct.create_workouts_table()