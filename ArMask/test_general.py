import pytest
import cv2
from unittest.mock import MagicMock, patch
from api_patern import *


@pytest.fixture
def mock_face_cascade():
    face_cascade = MagicMock(spec=cv2.CascadeClassifier)
    face_cascade.detectMultiScale.return_value = [(100, 100, 50, 50)]
    return face_cascade


def test_detect_faces(mock_face_cascade):
    frame = np.ones((480, 640, 3), dtype=np.uint8)
    faces = detect_faces(frame, mock_face_cascade)
    assert len(faces) == 1


def test_apply_mask():
    frame = np.ones((480, 640, 3), dtype=np.uint8)
    mask = np.ones((100, 100, 4), dtype=np.uint8) * 255
    faces = [(100, 100, 50, 50)]
    frame_with_mask = apply_mask(frame, mask, faces)
    assert frame_with_mask.shape == frame.shape


@patch('api_patern.cv2.VideoCapture', autospec=True)
def test_gen_frames_save_result(mock_face_cascade):
    with patch('api_patern.detect_faces', return_value=[(100, 100, 50, 50)], autospec=True):
        mask_loader = MaskLoaderFromLocal()
        gen = gen_frames('2.png', mask_loader, use_test_image=True, return_cv2=True)
        next(gen) 
        frame = next(gen)
        assert isinstance(frame, bytes)


@patch('api_patern.cv2.VideoCapture', autospec=True)
def test_gen_frames_save_result(mock_face_cascade):
    with patch('api_patern.detect_faces', return_value=[(100, 100, 50, 50)], autospec=True):
        mask_loader = MaskLoaderFromLocal()
        gen = gen_frames('2.png', mask_loader, use_test_image=True, return_cv2=True)
        next(gen) 
        frame = next(gen)

        cv2.imwrite('test_frame.jpg', frame)
