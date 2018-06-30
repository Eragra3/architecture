import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import {CreateLearningProgramComponent} from './create-learning-program.component';

describe('CreateLearningProgramComponent', () => {
  let component: CreateLearningProgramComponent;
  let fixture: ComponentFixture<CreateLearningProgramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CreateLearningProgramComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateLearningProgramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
