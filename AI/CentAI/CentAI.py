# kaiway.itch.io/centa
# https://keon.io/deep-q-learning/
# https://pythonprogramming.net/game-frames-open-cv-python-plays-gta-v/

from mss import mss  # from mss.windows import MSS as mss
from PIL import Image
import cv2

import numpy as np
import time

import pyautogui  # use scan codes if doesn't work
import pytesseract
from DQNAgent import DQNAgent


def capture_ss():
    img = sc.grab(monitor=sc.monitors[1])
    return np.array(Image.frombytes('RGB', img.size, img.bgra, 'raw', 'BGRX'))


def process_img(original_img):
    processed_img = cv2.resize(original_img, scr_dim, interpolation=cv2.INTER_AREA)
    processed_img = cv2.cvtColor(processed_img, cv2.COLOR_BGR2GRAY)
    return processed_img


def shape_img(processed_img):
    shaped_img = np.reshape(processed_img, [1, screen_size])
    return shaped_img


def act(action):
    print(action)
    if action > 4:
        if action < 20:
            if action % 4 == 0:
                pyautogui.keyDown('W')
            if action % 4 == 1:
                pyautogui.keyDown('A')
            if action % 4 == 2:
                pyautogui.keyDown('S')
            if action % 4 == 3:
                pyautogui.keyDown('D')
        else:
            if action == 20 or action == 21 or action == 24 or action == 25 or action == 28 or action == 29:
                pyautogui.keyDown('W')
            if action == 20 or action == 22 or action == 24 or action == 26 or action == 28 or action == 30:
                pyautogui.keyDown('A')
            if action == 23 or action == 22 or action == 27 or action == 26 or action == 31 or action == 30:
                pyautogui.keyDown('S')
            if action == 23 or action == 21 or action == 27 or action == 25 or action == 31 or action == 29:
                pyautogui.keyDown('D')
    if action == 0 or (8 <= action <= 11) or (20 <= action <= 23):
        pyautogui.keyDown('U')
    if action == 1 or (12 <= action <= 15) or (24 <= action <= 27):
        pyautogui.keyDown('I')
    if action == 2:
        pyautogui.keyDown('O')
    if action == 3 or (16 <= action <= 19) or (28 <= action <= 31):
        pyautogui.keyDown('P')


def reset():
    pyautogui.keyUp('W')
    pyautogui.keyUp('A')
    pyautogui.keyUp('S')
    pyautogui.keyUp('D')
    pyautogui.keyUp('U')
    pyautogui.keyUp('I')
    pyautogui.keyUp('O')
    pyautogui.keyUp('P')


def main():
    agent = DQNAgent(screen_size, 4 + 4 + 12 + 12)
    # agent.load()

    death_flag = process_img(capture_ss())[death_loc[1], death_loc[0]]
    print("starting")

    time.sleep(2)

    # repeat episode_num times
    for e in range(episode_num):
        pyautogui.keyDown('tab')
        pyautogui.keyUp('tab')

        score = 0
        dead = False
        last_scr = process_img(capture_ss())
        last_scr_vector = shape_img(last_scr)
        action = agent.act(last_scr_vector)
        act(action)
        last_time = time.time()

        while not dead:
            reset()
            screen = capture_ss()
            pro_scr = process_img(screen)
            scr_vector = shape_img(pro_scr)

            score_crop = screen[score_loc[1]:score_loc[1] + score_dim[1],
                         score_loc[0]:score_loc[0] + score_dim[0]]
            score_ocr = pytesseract.image_to_string(score_crop,
                                                    config='--psm 10 --oem 3 -c tessedit_char_whitelist=0123456789')
            if score_ocr != '':
                score = max(score, int(score_ocr))

            death_check = pro_scr[death_loc[1]][death_loc[0]]
            if death_flag == death_check:
                dead = True

            reward = score

            agent.remember(last_scr_vector, action, reward, scr_vector, dead)

            if dead:
                print('episode: {}/{}, score: {}'.format(e, episode_num, reward))
                continue

            print(time.time() - last_time)
            last_time = time.time()
            action = agent.act(scr_vector)
            act(action)
            last_scr = pro_scr
            last_scr_vector = scr_vector

        agent.replay(32)

    agent.save()


episode_num = 10
scr_dim = (200, 50)
score_loc = (1085, 150)
score_dim = (400, 150)
death_loc = (int(scr_dim[0] / 2), int(scr_dim[1] / 2))
screen_size = scr_dim[0] * scr_dim[1]

sc = mss()

time.sleep(4)
main()
