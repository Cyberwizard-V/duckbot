/* eslint-disable no-inline-comments */
const { SlashCommandBuilder } = require('discord.js');
const { joinVoiceChannel, getVoiceConnection, createAudioPlayer, createAudioResource, StreamType } = require('@discordjs/voice');
const { createReadStream } = require('fs');

module.exports = {
	data: new SlashCommandBuilder()
		.setName('duckduckvoice')
		.setDescription('Joins a voice channel and makes a quack sound!'),
	async execute(interaction) {
		if (!interaction.guild) {
			await interaction.reply('This command must be used in a guild.');
			return;
		}

		const guildId = interaction.guildId;
		const member = interaction.member;
		const voiceChannel = member.voice.channel;

		if (!voiceChannel) {
			await interaction.reply('You need to be in a voice channel to use this command.');
			return;
		}

		const channelId = voiceChannel.id; // Retrieve the channel ID of the voice channel

		const voiceAdapterCreator = interaction.guild.voiceAdapterCreator;

		if (!voiceAdapterCreator) {
			await interaction.reply('The voice adapter creator is not available in this guild.');
			return;
		}

		const connection = joinVoiceChannel({
			channelId: channelId,
			guildId: guildId,
			adapterCreator: voiceAdapterCreator,
		});

		const player = createAudioPlayer();

		const audioResource = createAudioResource(createReadStream('quack.mp3'), {
			inputType: StreamType.Arbitrary,
		});

		connection.subscribe(player);

		await new Promise(resolve => setTimeout(resolve, 1000));

		player.play(audioResource);

		console.log('Playing audio...');

		setTimeout(() => {
			const test = getVoiceConnection(guildId);
			if (test) {
				test.destroy();
				console.log('Left voice channel.');
			}
		}, 3000); // 10 seconds

		await interaction.reply('QUACK!!');
	},
};