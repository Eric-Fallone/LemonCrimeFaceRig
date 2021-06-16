import cv2
import numpy as np
import dlib
import time
import zmq
import json

cap = cv2.VideoCapture(0)

detector = dlib.get_frontal_face_detector()
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat")

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

def GetFaceLandMarks():
    _, frame = cap.read()
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    faces = detector(gray)
    output = [-1,0,0]
    for face in faces:
        
        x1 = face.left()
        x2 = face.top()
        y1 = face.right()
        y2 = face.bottom()
        #cv2.rectangle(frame, (x1,x2), (y1,y2), (0,255,0),0)

        landmarks = predictor(gray, face)
        
        for n in range(0,68):
            x = landmarks.part(n).x
            y = landmarks.part(n).y
            #print("Landmark: " + str(n) +" x: "+ str(x) + " Y: " + str(y))
            output.append([n,x,y])
            cv2.circle(frame, (x,y), 4, (255, 0, 0), -1)
        #print(output)
        #cv2.imshow("Frame", frame)

    output_json = json.dumps(output)
    return output_json

while True:
    GetFaceLandMarks()
    #  Wait for next request from client
    message = socket.recv()
    print("Received request: %s" % message)
    out_json = GetFaceLandMarks()
    time.sleep(.1)
    
    socket.send_json(out_json)
