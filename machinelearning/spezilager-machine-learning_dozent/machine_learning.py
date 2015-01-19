import numpy as np

def nearest_neighbor(data_train, target_train, data_test):
  prediction = [0 for i in range(len(data_test))]
  # gehe durch alle Test-Datenpunkte
  for i in range(len(data_test)):
    pass  # HIER MUSS EUER CODE REIN
  return prediction

def k_nearest_neighbors(data_train, target_train, data_test, k):
  prediction = [0 for i in range(len(data_test))]
  # gehe durch alle Test-Datenpunkte
  for i in range(len(data_test)):
    pass  # HIER MUSS EUER CODE REIN
  return prediction

def perceptron_learn(data_train, target_train, alpha=0.1):
  # füge eine konstante 1 als input an jedes beispiel an, dies ermöglicht den Schwellwert des Perzeptrons zu verschieben
  data_train = np.hstack([np.ones([data_train.shape[0], 1]), data_train])
  w = np.zeros(data_train.shape[1])
  # gehe 1000 mal durch alle Datenpunkte
  for i in range(1000): 
    for j in range(len(data_train)):
      pass  # HIER MUSS EUER CODE REIN
  return w

def perceptron_predict(w, data_test):
  # füge eine konstante 1 als input an jedes beispiel an, dies ermöglicht den Schwellwert des Perzeptrons zu verschieben
  data_test = np.hstack([np.ones([data_test.shape[0], 1]), data_test])
  prediction = [0 for i in range(len(data_test))]
  # HIER MUSS EUER CODE REIN
  return prediction
