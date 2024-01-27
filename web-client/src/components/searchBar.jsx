import React, { useState } from 'react';
import './searchBar.css';
import searchButton from '../res/search_button.png';

const SearchBar = ({ searchButtonClicked }) => {
    const [query, setQuery] = useState('');

    const handleInputChange = (event) => {
        setQuery(event.target.value);
    }

    const handleSearch = () => {
        searchButtonClicked(query);
    }

    return (
        <div className="search-bar">
            <input
                type="text"
                placeholder="Search..."
                value={query}
                onChange={handleInputChange}
            />
            <button onClick={handleSearch}>
                <img src={searchButton} alt="Search" />
            </button>
        </div>
    );
}

export default SearchBar;
