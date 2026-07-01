import sqlite3
import logs.logger as log
from .database_request_data import get_all_sports_data

def add_data_into_sport(name, characteristics):
    with sqlite3.connect('Logic\\Database_Logic\\data.db') as connection:
        sports = get_all_sports_data()

        # Check for 0 because the user may not have added any sport yet.
        if len(sports) == 0:
            connection.execute("INSERT INTO Sports VALUES(?, ?)", (name, characteristics))
            log.info_message_space(f"Sport {name} successfully added.")
        else:
            exist_in_database = False
            for sport in sports:
                if sport[0].lower() == name.lower():
                    exist_in_database = True

            if not exist_in_database:
                connection.execute("INSERT INTO Sports VALUES(?, ?)", (name, characteristics))
                log.info_message_space(f"Sport {name} successfully added.")
            else:
                log.info_message(f"Sport {name} has already been added.")

        connection.commit()