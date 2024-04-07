const { SlashCommandBuilder, EmbedBuilder } = require('discord.js');
const { getDuckGif } = require('../../api/duckgif.js');

module.exports = {
	// eslint-disable-next-line no-dupe-keys
	data: new SlashCommandBuilder()
		.setName('duckduckgif')
		.setDescription('Replies with duck gif'),
	// eslint-disable-next-line no-dupe-keys
	async execute(interaction) {
		try {
			const gifUrl = await getDuckGif();

			console.log(gifUrl);

			const embed = new EmbedBuilder()
				.setColor('#0099ff')
				.setTitle('🦆 ' + 'Duck gif')
				.setImage(gifUrl)
				.setTimestamp()
				.setFooter({ text: 'Quackgif', iconURL: 'https://i.imgur.com/ryjpL39.png' });

			await interaction.reply({ embeds: [embed] });
		}
		catch (error) {
			console.error(error);
			await interaction.reply('SORRY! SEEMS LIKE THE API IS NOT WORKING?!');
		}
	},
};