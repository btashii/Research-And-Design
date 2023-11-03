#Iterates to find most accurate hyperbolic eccentric anomaly F.
import math
import numpy as np

# Define your mathematical functions.
def newtonsmethod(e, M_h):
  global F_guess
  F = F_guess - (((e*np.sinh(F_guess)-F_guess-M_h))/(e*np.cosh(F_guess)-1))
  F_guess = F 
  print("Your latest F value: " + str(F))
  return F

# Prompt the user for input.
F_guess = float(input("Enter the value of F_guess: "))
e = float(input("Enter the value of Eccentricity e: "))
M_h = float(input("Enter the value of Mean Hyperbolic Eccentric Anomaly M_h: "))

# Print the results.
while True: 
  newtonsmethod(e, M_h)
  input("Enter to Iterate Again!")
