// eslint-disable-next-line no-unused-vars
const { getRandomInt } = require('../shared/sharedfunctions.js');

module.exports = { getDuckGif };

// Get giphy token
// const giphyAPI_token = process.env.giphyAPI_token;

// TODO: MAKE THE SEARCH ON THE GIF RANDOM
async function getDuckGif() {
	try {
		const fetch = await import('node-fetch');
		const response = await fetch.default('https://api.giphy.com/v1/gifs/random?api_key=2z5izGe2yEOupZwoVRu9iRvLdPOGe2j1&tag=DUCK&rating=g');
		const json = await response.json();
		const gifData = json.data;
		return gifData.images.original.url;
	}
	catch (error) {
		console.error('Failed to fetch duck gif:', error);
		return 'error';
	}
}