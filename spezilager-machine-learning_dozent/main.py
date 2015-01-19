from machine_learning import *
import numpy as np
from plotting_util import *

###############
# DATEN LADEN #
###############

use_fish_example = True  # True or False

if use_fish_example:
  # Daten laden: Fische-Beispiel
  data_train = np.loadtxt('datasets/fish_data_train.txt')  # Trainings-Merkmale: Helligkeit, Länge in cm
  data_test = np.loadtxt('datasets/fish_data_test.txt')  # Test-Merkmale: Helligkeit, Länge in cm
  target_train = np.loadtxt('datasets/fish_target_train.txt')  # Trainings-Labels: 0=Lachs, 1=Seebarsch
  target_test = np.loadtxt('datasets/fish_target_test.txt')  # Test-Labels: 0=Lachs, 1=Seebarsch
  target_names = ['Lachs', 'Seebarsch']
  feature_names = ['Helligkeit', 'Länge [cm]']
else:
  # Daten laden: Ziffern-Beispiel
  data_train = np.loadtxt('datasets/digits_data_train.txt')  # trainings-bilder: 8x8 Pixel
  data_test = np.loadtxt('datasets/digits_data_test.txt')  # test-bilder: 8x8 Pixel
  target_train = np.loadtxt('datasets/digits_target_train.txt')  # trainings-labels: Ziffer (0 bis 9)
  target_test = np.loadtxt('datasets/digits_target_test.txt')  # test-labels: Ziffer (0 bis 9)
  target_names = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']
  feature_names = None

#################
# DATEN PLOTTEN #
#################

if use_fish_example:
  plot_hist(data_train, target_train, target_names, feature_names, 0)
  plot_hist(data_train, target_train, target_names, feature_names, 1)
  plot_2d(data_train, target_train, target_names, feature_names, 0, 1)

if not use_fish_example:
  plot_images(data_train, target_train, rows=5, columns=10, title='Trainingsdaten')

##########
# LERNEN #
##########

# Vorhersage anhand nächstem Nachbarn
prediction_NN = nearest_neighbor(data_train, target_train, data_test)

# Vorhersage anhand der k nächsten Nachbarn
prediction_kNN = k_nearest_neighbors(data_train, target_train, data_test, 3)

if use_fish_example:
  # Perceptron Gewichte w lernen
  w = perceptron_learn(data_train, target_train)
  # Vorhersage mit gelernetm Perceptron
  prediction_perc = perceptron_predict(w, data_test)

#############
# AUSWERTEN #
#############

total = len(target_test)

correct_NN = np.sum(prediction_NN == target_test)
print("NN hat {} von {} Testdaten korrekt erkannt ({:.2f}%)".format(correct_NN, total, 100 * correct_NN / total))

if not use_fish_example:
  plot_images(data_test, prediction_NN, rows=5, columns=10, title='Durch Nearest Neighbor Methode bestimmte Ziffern')

correct_kNN = np.sum(prediction_kNN == target_test)
print("kNN hat {} von {} Testdaten korrekt erkannt ({:.2f}%)".format(correct_kNN, total, 100 * correct_kNN / total))

if use_fish_example:
  correct_perc = np.sum(prediction_perc == target_test)
  print("Perzeptron hat {} von {} Testdaten korrekt erkannt ({:.2f}%)".format(correct_perc, total, 100 * correct_perc / total))
  
input("Drücke Enter zum Beenden...")
