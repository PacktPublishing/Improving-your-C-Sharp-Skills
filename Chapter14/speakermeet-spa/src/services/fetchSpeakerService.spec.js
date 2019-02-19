import { expect } from 'chai';
import sinon from 'sinon';
import fetchPonyfill from 'fetch-ponyfill';
const { Response, Headers } = fetchPonyfill();
import * as errorTypes from '../reducers/errorTypes';
import FetchSpeakerService from './fetchSpeakerService';

describe('Fetch Speaker Service', () => {
  it('exits', () => {
    expect(FetchSpeakerService).to.exist;
  });

  it('can be constructed', () => {
    // arrange
    let service = new FetchSpeakerService();

    // assert
    expect(service).to.be.an.instanceof(FetchSpeakerService);
  });

  describe('After Initialization', () => {
    let service = null;
    let fetch = null;

    beforeEach(() => {
      fetch = sinon.stub(global, 'fetch');
      service = new FetchSpeakerService('http://localhost');
    });

    afterEach(() => {
      fetch.restore();
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
          // arrange
          fetch.returns(okResponse([]));

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
          fetch.returns(okResponse([{}]));

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
          // arrange
          fetch.returns(notFoundResponse());

          // act
          const promise = service.getById('fake-speaker');

          // assert
          return promise
            .then(() => {
              throw { type: 'Error not returned' };
            })
            .catch(error => {
              expect(error.type).to.equal(errorTypes.SPEAKER_NOT_FOUND);
            });
        });
      });

      describe('Speaker Exists', () => {
        it('returns the speaker', () => {
          // arrange
          const speaker = {
            id: 'test-speaker'
          };
          fetch.returns(okResponse(speaker));

          // act
          let promise = service.getById('test-speaker');

          // assert
          return promise.then(speaker => {
            expect(speaker).to.not.be.null;
            expect(speaker.id).to.equal('test-speaker');
          });
        });
      });
    });
  });
});

function baseResponse() {
  let response = new Response();
  response.headers = new Headers({
    'Content-Type': 'application/json'
  });
  response.ok = true;
  response.status = 200;
  response.statusText = 'OK';

  return response;
}

function okResponse(body) {
  return new Promise((resolve, reject) => {
    let response = baseResponse();
    response.body = JSON.stringify(body);

    resolve(response);
  });
}

function notFoundResponse() {
  return new Promise((resolve, reject) => {
    let response = baseResponse();
    response.ok = false;
    response.status = 404;
    response.statusText = 'NOT FOUND';

    resolve(response);
  });
}
