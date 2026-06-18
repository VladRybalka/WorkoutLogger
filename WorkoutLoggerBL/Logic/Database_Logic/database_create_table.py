import sqlite3

def create_workouts_table():
    connection = sqlite3.connect('Logic\\Database_Logic\\data.db')
    cursor = connection.cursor()
    cursor.execute(f"CREATE TABLE IF NOT EXISTS Workouts (ID INTEGER PRIMARY KEY AUTOINCREMENT, "
                                                          f"Year INTEGER,"
                                                          f"Month INTEGER,"
                                                          f"Day INTEGER,"
                                                          f"Sport TEXT)")
    connection.commit()
    cursor.close()
    connection.close()

def create_sport_table():
    connection = sqlite3.connect('Logic\\Database_Logic\\data.db')
    cursor = connection.cursor()
    cursor.execute(f"CREATE TABLE IF NOT EXISTS Sports (ID INTEGER PRIMARY KEY AUTOINCREMENT,"
                                                        f"Name TEXT,"
                                                        f"Characteristics TEXT)")
    connection.commit()
    cursor.close()
    connection.close()