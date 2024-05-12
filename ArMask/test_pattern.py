from api_patern import MaskLoaderFromLocal, MaskLoaderFromUrl, detect_faces, apply_mask, gen_frames
import pytest

@pytest.fixture
def local_mask_loader():
    return MaskLoaderFromLocal()

@pytest.fixture
def url_mask_loader():
    return MaskLoaderFromUrl()

@pytest.fixture
def mock_frame():
    return 'mock_frame_data'

def test_load_mask_local(local_mask_loader):
    result = local_mask_loader.load_mask('2.png')
    assert result is not None

def test_load_mask_url(url_mask_loader):
    with pytest.raises(Exception):
        result = url_mask_loader.load_mask('https://localhost:7042/help/getimagebyid/653927fb47981feeebf70d97/1')

def test_detect_faces(mock_frame):
    with pytest.raises(Exception):
        result = detect_faces(mock_frame, 'mock_face_cascade')

def test_apply_mask(mock_frame):
    with pytest.raises(Exception):
        result = apply_mask(mock_frame, 'mask', [(10, 10, 10, 10)])

def test_gen_frames(local_mask_loader):
    frames = gen_frames('2.png', local_mask_loader)
    assert frames is not None

# Additional tests
def test_local_mask_loader_toggle_streaming(local_mask_loader):
    with pytest.raises(Exception):
        local_mask_loader.toggle_streaming('mock_image')

def test_url_mask_loader_toggle_streaming(url_mask_loader):
    with pytest.raises(Exception):
        url_mask_loader.toggle_streaming('mock_image')

def test_detect_faces_empty_frame():
    with pytest.raises(Exception):
        detect_faces(None, 'mock_face_cascade')

def test_apply_mask_empty_frame():
    with pytest.raises(Exception):
        apply_mask(None, 'mask', [(10, 10, 10, 10)])

def test_not_crashing_gen_frames_invalid_image(local_mask_loader):
    gen_frames('does_not_exist.png', local_mask_loader, use_test_image=True)

def test_not_crashing_gen_frames_no_loader():
    gen_frames('2.png', None, use_test_image=True)

