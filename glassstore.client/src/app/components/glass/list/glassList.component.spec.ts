import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlassListComponent } from './glassList.component';

describe('GlassComponent', () => {
  let component: GlassListComponent;
  let fixture: ComponentFixture<GlassListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GlassListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GlassListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
