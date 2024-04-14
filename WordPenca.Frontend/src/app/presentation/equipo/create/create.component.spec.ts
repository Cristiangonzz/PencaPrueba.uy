import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateEquipoComponent } from './create.component';



describe('CreateComponent', () => {
  let component: CreateEquipoComponent;
  let fixture: ComponentFixture<CreateEquipoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateEquipoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
