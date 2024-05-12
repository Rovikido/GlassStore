import pytest
import threading
import time
import cv2
from unittest.mock import MagicMock, patch
from api_patern import *



def test_index():
    response = app.test_client().get('/')
    assert response.status_code == 302


def test_stop_stream():
    response = app.test_client().get('/stop_stream')
    assert response.status_code == 200
    assert response.data == b'Stream stopped'


def test_index_redirects_to_video_feed():
    response = app.test_client().get('/')
    assert response.status_code == 302
    assert response.headers['Location'] == '/None'


def test_stop_stream_route():
    response = app.test_client().get('/stop_stream')
    assert response.status_code == 200
    assert response.data == b'Stream stopped'
