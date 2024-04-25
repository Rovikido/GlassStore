import { TestBed } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserService } from './User.service';


describe('UserService', () => {
  let service: UserService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [UserService]
    });

    service = TestBed.inject(UserService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should fetch user by id', () => {
    const mockUser = {
      email: 'q@gmail.com',
      orders: [
        {
          glasses: [
            {
              id: '653927fb47981feeebf70d97',
              price: '203',
              brand: 'Ray-Ban',
              model: 'Wayfarer',
              frameColor: 'Matte Black',
              lensColor: 'Black Gradient',
              frameMaterial: 'Nylon',
              lensMaterial: 'Glass',
              isPrescription: false,
              prescriptionType: 'false',
              frameWidth: 50,
              bridgeWidth: 22,
              templeLength: 145,
              gender: 'Unisex',
              shape: 'Wayfarer',
              style: ['Classic', 'Timeless'],
              photos: ['iVBORw0KGgoAAAANSUhEUgAACAAA', 'iVBORw0KGgoAAAANSUhEUgAACAAA', 'iVBORw0KGgoAAAANSUhEUgAACAAA'],
            }
          ],
          totalPrice: 203,
          orderDate: new Date('2024-04-23T10:32:20.214Z')
        },
        // Добавьте больше заказов, если нужно
      ],
      basket: null,
      roles: [1]
    };



    service.getuser().subscribe(user => {
      expect(user).toEqual(user);
    });

    const req = httpMock.expectOne('api/users/1');
    expect(req.request.method).toBe('GET');

    req.flush(mockUser);
  });

  afterEach(() => {
    httpMock.verify();
  });
});



