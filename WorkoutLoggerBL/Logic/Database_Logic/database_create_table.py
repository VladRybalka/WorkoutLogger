import sqlite3
from .database_adding_data import add_data_into_sport
from .database_data_request import get_all_sports

# Create table for workouts.
def create_workouts_table():
    sports = get_all_sports()
    print(sports)

    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        for row in sports:
            connection.execute(f"CREATE TABLE IF NOT EXISTS Workouts_{row[0]} (ID INTEGER PRIMARY KEY AUTOINCREMENT, "
                                                                              "Year INTEGER,"
                                                                              "Month INTEGER,"
                                                                              "Day INTEGER)")
        connection.commit()

# Create table for storing a list of added sports.
def create_sport_table():
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        connection.execute("CREATE TABLE IF NOT EXISTS Sports (Name TEXT PRIMARY KEY, "
                                                       "Characteristics TEXT)")
        connection.commit()

    add_data_into_sport("Run", "Time;Distance")
    add_data_into_sport("Walk", "Time;Distance")