import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

describe('Navbar Design', () => {
  it('should have a home link in the navbar', () => {
      render(<App/>);
      const navLink = screen.getByText(/Home/i);
      expect(navLink).toBeInTheDocument();
  });

  it('should have a Register user link in the navbar', () => {
    render(<App/>);
    const navLink = screen.getByText(/Sign Up/i);
    expect(navLink).toBeInTheDocument();
  });

  it('should have a Login link in the navbar', () => {
    render(<App/>);
    const navLink = screen.getByText(/Sign In/i);
    expect(navLink).toBeInTheDocument();
  });

});