import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlassInfoComponent } from './glassInfo.component';

describe('GlassInfoComponent', () => {
  let component: GlassInfoComponent;
  let fixture: ComponentFixture<GlassInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GlassInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GlassInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
