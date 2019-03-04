import cv2
import sys 
import numpy as np
import os
import cv2
import numpy as np
from PIL import Image
detector=cv2.CascadeClassifier('C:/Python27/frc/haarcascade_frontalface_default.xml');
recognizer=cv2.createLBPHFaceRecognizer();
path='C:/Python27/frc/dataSet'
cam=cv2.VideoCapture(0);

'''
def insertOrUpdate(Id,Name):
	con = mysql.connector.connect(user = 'root', password = '2575', host = 'localhost', database = 'facevote1')
	mycursor = con.cursor()
	mycursor.execute("SELECT * FROM people WHERE ID='%s'" % (Id))
	isRecordExist=0
	for row in mycursor:
		isRecordExist=1
	if(isRecordExist==1):
		mycursor.execute("UPDATE people SET Name= '%s' WHERE ID = '%s'" % (Name, Id))
	else:
		mycursor.execute("INSERT INTO people(ID,Name) Values(%s,%s)" % (Name, Id))
	con.commit()
	con.close()
	
id = str(sys.argv[1])  
name = str(sys.argv[2])
insertOrUpdate(id,name)
'''
sampleNum=0;
id = int(sys.argv[1]) 
while(True):
	ret,img=cam.read();
	gray=cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
	faces=detector.detectMultiScale(gray,1.3,5);
	for(x,y,w,h) in faces:
		sampleNum=sampleNum+1;
		cv2.imwrite("C:/Python27/frc/dataSet/User."+str(id)+"."+str(sampleNum)+".jpg",gray[y:y+h,x:x+w])
		cv2.rectangle(img,(x,y),(x+w,y+h),(0,255,0),2)
		cv2.waitKey(100);
	cv2.imshow("Face",img);
	cv2.waitKey(1);
	if(sampleNum>20):	
		break;
sys.stdout.write("YES")
cam.release()
cv2.destroyAllWindows()

def getImagesWithID(path):
	imagePaths=[os.path.join(path,f) for f in os.listdir(path)]
	faces=[]
	IDs=[]
	for imagePath in imagePaths:
		faceImg=Image.open(imagePath).convert('L');
		faceNp=np.array(faceImg,'uint8')
		ID=int(os.path.split(imagePath)[-1].split('.')[1])
		faces.append(faceNp)
		IDs.append(ID)
		cv2.imshow("training",faceNp)
		cv2.waitKey(10)
	return np.array(IDs), faces
	
Ids, faces=getImagesWithID(path)
recognizer.train(faces,Ids)
recognizer.save('C:/Python27/frc/recognizer/training.yml')
cv2.destroyAllWindows()
