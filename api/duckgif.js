const { searchduckdata } = require('../data/ducksearch.json');
// eslint-disable-next-line no-unused-vars
const { getRandomInt } = require('../shared/sharedfunctions.js');

module.exports = { getDuckGif };

// Get giphy token
// const giphyAPI_token = process.env.giphyAPI_token;

// TODO: MAKE THE SEARCH ON THE GIF RANDOM
async function getDuckGif() {
	// Get random value from data
	const randomString = searchduckdata[getRandomInt(searchduckdata.length)];
	const result = randomString.replaceAll(' ', '+');
	try {
		const fetch = await import('node-fetch');
		const response = await fetch.default(`https://api.giphy.com/v1/gifs/search?api_key=2z5izGe2yEOupZwoVRu9iRvLdPOGe2j1&q=${result}&limit=1&offset=0&rating=g&lang=en&bundle=messaging_non_clips`);
		const json = await response.json();
		const gifData = json.data[0];
		return gifData.url;
	}
	catch (error) {
		console.error('Failed to fetch duck gif:', error);
		return 'error';
	}
}