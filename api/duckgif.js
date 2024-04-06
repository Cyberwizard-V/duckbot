module.exports = { getDuckGif };

// GetDuckGif through API of GIPHY
async function getDuckGif() {
	try {
		const fetch = await import('node-fetch');
		const response = await fetch.default('https://api.giphy.com/v1/gifs/search?api_key=2z5izGe2yEOupZwoVRu9iRvLdPOGe2j1&q=Duck&limit=1&offset=0&rating=g&lang=en&bundle=messaging_non_clips');
		const json = await response.json();
		const gifData = json.data[0];
		return gifData.url;
	}
	catch (error) {
		console.error('Failed to fetch duck gif:', error);
		return 'error';
	}
}