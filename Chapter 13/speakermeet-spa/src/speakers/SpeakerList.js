import React from 'react';
import { SpeakerListRow } from './SpeakerListRow';

export const SpeakerList = ({speakers}) => {
    let contents = <div>Error!</div>;
  
    if(speakers.length === 0) {
      contents = <div id="no-speakers">No Speakers Available.</div>;
    } else {
      contents = (
        <table className="table">
          <thead>
            <tr>
              <th>Name</th>
              <th></th>
            </tr>
          </thead>
          <tbody className="speakers">
            { 
              speakers.map(speaker => 
                <SpeakerListRow key={speaker.id} speaker={speaker} />) 
            }
          </tbody>
        </table>
      );
    }
  
    return (
      <div>
      <h1>Speakers</h1>
      { contents }
      </div>
    );
  };
