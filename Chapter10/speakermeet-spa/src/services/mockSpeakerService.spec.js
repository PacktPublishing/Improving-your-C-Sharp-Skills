import { expect } from 'chai';
import * as errorTypes from '../reducers/errorTypes';
import { MockSpeakerService } from '../services/mockSpeakerService';

describe('Mock Speaker Service', () => {
  it('exits', () => {
    expect(MockSpeakerService).to.exist;
  });

  it('can be constructed', () => {
    // arrange
    let service = new MockSpeakerService();

    // assert
    expect(service).to.be.an.instanceof(MockSpeakerService);
  });

  describe('After Initialization', () => {
    let service = null;

    beforeEach(() => {
      service = new MockSpeakerService();
    });

    describe('Create', () => {
      it('exists', () => {
        expect(service.create).to.exist;
      });
    });

    describe('Get All', () => {
      it('exists', () => {
        // assert
        expect(service.getAll).to.exist;
      });

      describe('No Speakers Exist', () => {
        it('returns an empty array', () => {
          // act
          let promise = service.getAll();

          // assert
          return promise.then(result => {
            expect(result).to.have.lengthOf(0);
          });
        });
      });

      describe('Speaker Listing', () => {
        it('returns speakers', () => {
          // arrange
          service.create({});

          // act
          let promise = service.getAll();

          // assert
          return promise.then(result => {
            expect(result).to.have.lengthOf(1);
          });
        });
      });
    });

    describe('Get Speaker By Id', () => {
      it('exists', () => {
        // assert
        expect(service.getById).to.exist;
      });

      describe('Speaker Does Not Exist', () => {
        it('SPEAKER_NOT_FOUND error is generated', () => {
          // act
          const promise = service.getById('fake-speaker');

          // assert
          return promise.catch(error => {
            expect(error.type).to.equal(errorTypes.SPEAKER_NOT_FOUND);
          });
        });
      });

      describe('Speaker Exists', () => {
        it('returns the speaker', () => {
          // arrange
          const speaker = { id: 'test-speaker' };
          service.create(speaker);
      
          // act
          let promise = service.getById('test-speaker');
      
          // assert
          return promise.then((speaker) => {
            expect(speaker).to.not.be.null;
            expect(speaker.id).to.equal('test-speaker');
          });
        });
      });
    });
  });
});
