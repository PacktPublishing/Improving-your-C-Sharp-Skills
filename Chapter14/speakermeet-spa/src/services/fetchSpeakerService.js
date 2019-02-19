import * as errorTypes from '../reducers/errorTypes';
import SpeakerService from './speakerService';

export default class FetchSpeakerService extends SpeakerService {
  constructor(baseUrl) {
    super();

    this.baseUrl = baseUrl;
  }

  create(speaker) {
    return;
  }

  getAll() {
    return fetch(`${this.baseUrl}/speakers`).then(r => {
      return r.json();
    });
  }

  getById(id) {
    return new Promise((resolve, reject) => {
      fetch(`${this.baseUrl}/speakers/${id}`).then((response) => {
        if (response.ok) {
          resolve(response.json());
        } else {
          reject({
            type: errorTypes.SPEAKER_NOT_FOUND
          });
        }
      });
    });
  }
}
