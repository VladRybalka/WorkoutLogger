import logging as log

# Log settings
logger = log.getLogger(__name__)
logger.setLevel(log.INFO)
fileHandler = log.FileHandler(filename='logs\\server.log', mode='w')
fileHandler.setFormatter(log.Formatter("%(asctime)s - %(levelname)s - %(message)s"))
logger.addHandler(fileHandler)

def info_message_space(message):
    logger.info("")
    logger.info(message)

def info_message(message):
    logger.info(message)