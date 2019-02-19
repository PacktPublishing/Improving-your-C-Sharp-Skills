import React from 'react';
import {NavLink} from 'react-router-dom';

const Header = () => {
  return (
    <nav>
      <NavLink to={'/'} activeClassName={'active'}>Home</NavLink>
      {' | '}
      <NavLink to={'/speakers'} activeClassName={'active'}>Speakers</NavLink>
      {' | '}
      <NavLink to={'/about'} activeClassName={'active'}>About</NavLink>
    </nav>
  );
};

export default Header;
