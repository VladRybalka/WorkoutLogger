import sqlite3
import logs.logger as log
from .database_adding_data import add_data_into_sport
from .database_request_data import get_all_sports_data
from .database_adding_column import add_columns

# Create table for workouts.
def create_workouts_table():
    sports = get_all_sports_data()

    # connection = sqlite3.connect('Logic\\Database_Logic\\data.db')
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        for row in sports:
            tables = [table[0] for table in connection.execute("SELECT name FROM sqlite_master WHERE type='table'")]
            if "Workouts_" + row[0] not in tables:
                log.info_message_space(f"Table Workouts_{row[0]} successfully added.")
                connection.execute(f"CREATE TABLE IF NOT EXISTS Workouts_{row[0]} "
                                    "(ID INTEGER PRIMARY KEY AUTOINCREMENT, "
                                    "Year INTEGER,"
                                    "Month INTEGER,"
                                    "Day INTEGER)")
                connection.commit()
                # connection.close()

                add_columns(row[0], [x.split(":") for x in row[1].split(";")])
            else:
                log.info_message(f"Table Workouts_{row[0]} has already been added.")

# Create table for storing a list of added sports.
def create_sport_table():
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        tables = [table[0] for table in connection.execute("SELECT name FROM sqlite_master WHERE type='table'")]
        if "Sports" not in tables:
            log.info_message("Create Sports table.")
            connection.execute("CREATE TABLE IF NOT EXISTS Sports (Name TEXT PRIMARY KEY, "
                               "Characteristics TEXT)")
            connection.commit()
        else:
            log.info_message("Sports table already exists.")

    add_data_into_sport("Run", "Time:INTEGER;Distance:DECIMAL")