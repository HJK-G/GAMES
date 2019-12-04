from PIL import Image
from mss import mss
import pytesseract
import cv2
import numpy as np
import time


def capture_ss():
    img = sct.grab(monitor=sct.monitors[1])
    return Image.frombytes('RGB', img.size, img.bgra, 'raw', 'BGRX')


def process_img(original_img):
    processed_img = cv2.resize(original_img, screen_dim, interpolation=cv2.INTER_AREA)
    processed_img = cv2.cvtColor(processed_img, cv2.COLOR_BGR2GRAY)
    return processed_img


screen_dim = (600, 400)
score_loc = (1085, 150)
score_dim = (400, 150)
death_loc = (int(screen_dim[0] / 2), int(screen_dim[1] / 2))
screen_size = screen_dim[0] * screen_dim[1]

sct = mss()

time.sleep(2)
last_time = time.time()
death_pixel = process_img(np.array(capture_ss()))[death_loc[1], death_loc[0]]
print(death_pixel)

while True:
    print('loop took {} seconds'.format(time.time() - last_time))
    last_time = time.time()
    screen = np.array(capture_ss())
    processed_screen = process_img(screen)
    cropped_screen = screen[score_loc[1]:score_loc[1] + score_dim[1], score_loc[0]:score_loc[0] + score_dim[0]]
    score_ocr = pytesseract.image_to_string(cropped_screen,
                                            config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')
    if str.isdigit(score_ocr):
        print(int(score_ocr))

    check_death_pixel = processed_screen[death_loc[1], death_loc[0]]
    print(check_death_pixel)

    cv2.imshow('window', processed_screen)
    if cv2.waitKey(25) & 0xFF == ord('q'):
        cv2.destroyAllWindows()
        break
