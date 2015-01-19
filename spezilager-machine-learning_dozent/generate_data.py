import numpy as np
from sklearn import datasets
from sklearn.cross_validation import train_test_split

# DIGITS DATASET
digits = datasets.load_digits()

digits_data_train, digits_data_test, digits_target_train, digits_target_test = train_test_split(digits.data, digits.target, test_size=0.20, random_state=42)

np.savetxt('digits_data_train.txt', digits_data_train, fmt='%10.5f')
np.savetxt('digits_data_test.txt', digits_data_test, fmt='%10.5f')
np.savetxt('digits_target_train.txt', digits_target_train, fmt='%10.5f')
np.savetxt('digits_target_test.txt', digits_target_test, fmt='%10.5f')

# FISH DATASET
n = 400
fish_target = np.hstack([np.zeros([n/2]), np.ones([n/2])]).astype(int)
fish_data = np.vstack([np.hstack([np.random.randn(n/2,1)*1+5, 2.5*(np.random.randn(n/2,1)*3+17)]),np.hstack([np.random.randn(n/2,1)*1+7.5, 2.5*(np.random.randn(n/2,1)*2+20)])])

fish_data_train, fish_data_test, fish_target_train, fish_target_test = train_test_split(fish_data, fish_target, test_size=0.20, random_state=42)

np.savetxt('fish_data_train.txt', fish_data_train, fmt='%10.5f')
np.savetxt('fish_data_test.txt', fish_data_test, fmt='%10.5f')
np.savetxt('fish_target_train.txt', fish_target_train, fmt='%10.5f')
np.savetxt('fish_target_test.txt', fish_target_test, fmt='%10.5f')

#np.loadtxt('test.txt')
