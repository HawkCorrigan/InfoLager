import matplotlib.pyplot as plt
import numpy as np

def plot_hist(data, target, target_names, feature_names=None, dim=0, title=None):
  plt.ion()
  plt.figure(title)
  bins = np.linspace(np.floor(np.min(data[:, dim])), np.ceil(np.max(data[:, dim])), 20)
  for y in range(len(target_names)):
    indices = np.where(target == y)
    plt.hist(data[indices, dim].T, bins, alpha=0.5, label=target_names[y])
  plt.legend(loc='best')
  if feature_names == None:
    plt.xlabel('Merkmal {}'.format(dim))
  else:
    plt.xlabel(feature_names[dim])
  plt.ylabel('Anzahl')

def plot_2d(data, target, target_names, feature_names=None, dim_x=0, dim_y=1, title=None):
  plt.ion()
  plt.figure(title)
  plt.hold(False)
  for y in range(len(target_names)):
    indices = np.where(target == y)
    plt.plot(data[indices, dim_x].T, data[indices, dim_y].T, 'o', markersize=7, label=target_names[y])
    plt.hold(True)
  plt.legend(loc='best')
  if feature_names == None:
    plt.xlabel('Merkmal {}'.format(dim_x))
    plt.ylabel('Merkmal {}'.format(dim_y))
  else:
    plt.xlabel(feature_names[0])
    plt.ylabel(feature_names[1])

def plot_images(data, target, rows=3, columns=6, title=None):
  plt.ion()
  plt.figure(title)
  plt.gray()
  plt.subplots_adjust(hspace=.5)
  for i in range(np.min([len(data), rows * columns ])):
    plt.subplot(rows, columns, i)
    plt.imshow(np.reshape(data[i], [8, 8]), interpolation='None')
    plt.xlabel(int(target[i]))
    plt.xticks([])
    plt.yticks([])
