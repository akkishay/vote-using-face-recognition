import sys
import cv2,os
import numpy as np
from PIL import Image 
import pickle
import time
import mysql.connector

recognizer = cv2.createLBPHFaceRecognizer()
recognizer.load('C:/Python27/frc/recognizer/training.yml')
cascadePath = "C:/Python27/frc/haarcascade_frontalface_default.xml"
faceCascade = cv2.CascadeClassifier(cascadePath);
path = 'C:/Python27/frc/dataSet'

def getProfile(id):
	con = mysql.connector.connect(user = 'root', password = '2575', host = 'localhost', database = 'face')
	mycursor = con.cursor()
	mycursor.execute("SELECT * FROM voter WHERE vid='%s'" % (id))
	profile=None
	for row in mycursor:
		profile=row
	con.close()
	return profile
	
cam = cv2.VideoCapture(0)
font = cv2.cv.InitFont(cv2.cv.CV_FONT_HERSHEY_SIMPLEX, 1, 1, 0, 1, 1) #Creates a font
samplenum = 0;
while True:
	ret, im =cam.read()
	gray=cv2.cvtColor(im,cv2.COLOR_BGR2GRAY)
	faces=faceCascade.detectMultiScale(gray, scaleFactor=1.2, minNeighbors=5, minSize=(100, 100), flags=cv2.CASCADE_SCALE_IMAGE)
	for(x,y,w,h) in faces:
		samplenum = samplenum + 1;
		id, conf = recognizer.predict(gray[y:y+h,x:x+w])
		if(conf<50):
			cv2.rectangle(im,(x,y),(x+w,y+h),(225,255,255),2)
			profile=getProfile(id)
			if(profile!=None):
				cv2.cv.PutText(cv2.cv.fromarray(im),str(profile[0]),(x,y+h+30),font,(255,255,255))
				cv2.cv.PutText(cv2.cv.fromarray(im),str(profile[1]),(x,y+h+60),font,(255,255,255))
		else:
			cv2.cv.PutText(cv2.cv.fromarray(im),'Unknown',(x,y+h+30),font,(255,255,255))
		cv2.imshow('Capture',im)
		cv2.waitKey(100)
	if(samplenum>50):	
		break;
sys.stdout.write(str(profile[0]))
cam.release()
cv2.destroyAllWindows()