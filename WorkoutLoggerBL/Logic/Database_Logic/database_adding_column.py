import sqlite3
import logs.logger as log

# column_name: [[name, type], [name,type]]
def add_columns(table_name, column_name):
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        cursor = connection.cursor()
        for column in column_name:
            cursor.execute(f"ALTER TABLE Workouts_{table_name} ADD COLUMN {column[0]} {column[1]}")
            log.info_message(f"[{column[0]} with type {column[1]}] added to table {table_name}")
        connection.commit()