using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content;

/// <summary>
/// Manages loading and unloading of game assets, including support for localized assets. Provides access to a service
/// provider and root directory.
/// </summary>
public interface IContentManager : IDisposable
{
    /// <summary>
    /// Gets the service provider instance used by this ContentManager.
    /// </summary>
    IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Gets or Sets the root directory that this ContentManager will search for assets in.
    /// </summary>
    string RootDirectory { get; set; }

    /// <summary>
    /// Loads an asset that has been processed by the Content Pipeline.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method attempts to load the asset based on the <see cref="CultureInfo.CurrentCulture"/>
    ///         searching for the asset by name and appending it with the culture name (e.g. "assetName.en-US")
    ///         or two letter ISO language name (e.g. "assetName.en"). If unsuccessful in finding the asset with
    ///         the culture information appended, it will fall back to loading the default asset.
    ///     </para>
    ///     <para>
    ///         Before a ContentManager can load an asset, you need to add the asset to your game project using
    ///         the steps described in
    ///         <see href="https://docs.monogame.net/articles/getting_started/content_pipeline/index.html">Adding Content - MonoGame</see>.
    ///     </para>
    /// </remarks>
    /// <typeparam name="T">
    ///     <para>
    ///         The type of asset to load.
    ///     </para>
    ///     <para>
    ///         <see cref="Effect"/>, <see cref="Model"/>, <see cref="Audio.SoundEffect"/>,
    ///         <see cref="Media.Song"/>, <see cref="SpriteFont"/>, <see cref="Texture"/>, <see cref="Texture2D"/>,
    ///         and <see cref="TextureCube"/> are all supported by default by the standard Content Pipeline
    ///         processor, but additional types may be loaded by extending the processor.
    ///     </para>
    /// </typeparam>
    /// <param name="assetName">
    /// The asset name, relative to the <see cref="RootDirectory">ContentManager.RootDirectory</see>, and not
    /// including the .xnb extension.
    /// </param>
    /// <returns>
    /// The loaded asset. Repeated calls to load the same asset will return the same object instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">The <paramref name="assetName"/> parameter is null or an empty string.</exception>
    /// <exception cref="ObjectDisposedException">This was called after the ContentManger was disposed.</exception>
    /// <exception cref="ContentLoadException">
    /// The type of the <paramref name="assetName"/> in the file does not match the type of asset requested as
    /// specified by <typeparamref name="T"/>.
    ///
    /// -or-
    ///
    /// A content file matching the <paramref name="assetName"/> parameter could not be found.
    ///
    /// -or-
    ///
    /// The specified path in the <paramref name="assetName"/> parameter is invalid (for example, a
    /// directory in the path does not exist).
    ///
    /// -or-
    ///
    /// An error occurred while opening the content file.
    /// </exception>
    T LoadLocalized<T> (string assetName);

    /// <summary>
    /// Loads an asset that has been processed by the Content Pipeline.
    /// </summary>
    /// <remarks>
    /// Before a ContentManager can load an asset, you need to add the asset to your game project using
    /// the steps described in
    /// <see href="https://docs.monogame.net/articles/getting_started/content_pipeline/index.html">Adding Content - MonoGame</see>.
    /// <br>PNG, JPG/JPEG and BMP files can be loaded as Texture2D without using the content pipeline. The assetName must not contain extension.
    /// </remarks>
    /// <typeparam name="T">
    ///     <para>
    ///         The type of asset to load.
    ///     </para>
    ///     <para>
    ///         <see cref="Effect"/>, <see cref="Model"/>, <see cref="Audio.SoundEffect"/>,
    ///         <see cref="Media.Song"/>, <see cref="SpriteFont"/>, <see cref="Texture"/>, <see cref="Texture2D"/>,
    ///         and <see cref="TextureCube"/> are all supported by default by the standard Content Pipeline
    ///         processor, but additional types may be loaded by extending the processor.
    ///     </para>
    /// </typeparam>
    /// <param name="assetName">
    /// The asset name, relative to the <see cref="RootDirectory">ContentManager.RootDirectory</see>, and not
    /// including the .xnb extension.
    /// </param>
    /// <returns>
    /// The loaded asset. Repeated calls to load the same asset will return the same object instance.
    /// </returns>
    /// <exception cref="ArgumentNullException">The <paramref name="assetName"/> parameter is null or an empty string.</exception>
    /// <exception cref="ObjectDisposedException">This was called after the ContentManger was disposed.</exception>
    /// <exception cref="ContentLoadException">
    /// The type of the <paramref name="assetName"/> in the file does not match the type of asset requested as
    /// specified by <typeparamref name="T"/>.
    ///
    /// -or-
    ///
    /// A content file matching the <paramref name="assetName"/> parameter could not be found.
    ///
    /// -or-
    ///
    /// The specified path in the <paramref name="assetName"/> parameter is invalid (for example, a
    /// directory in the path does not exist).
    ///
    /// -or-
    ///
    /// An error occurred while opening the content file.
    /// </exception>
    T Load<T>(string assetName);

    /// <summary>
    /// Unloads all assets that were loaded by this ContentManger.
    /// </summary>
    /// <remarks>
    /// If an asset being unloaded implements the <see cref="IDisposable"/> interface, then the
    /// <see cref="IDisposable.Dispose">IDisposable.Dispose</see> method will be called before unloading.
    /// </remarks>
    void Unload();

    /// <summary>
    /// Unloads a single asset that was loaded by this ContentManager.
    /// </summary>
    /// <remarks>
    /// If the asset being unloaded implements the <see cref="IDisposable"/> interface, then the
    /// <see cref="IDisposable.Dispose">IDisposable.Dispose </see > method will be called before unloading.
    /// </remarks>
    /// <param name="assetName">
    /// The asset name, relative to the <see cref="RootDirectory">ContentManager.RootDirectory</see>, and not
    /// including the .xnb extension.
    /// </param>
    /// <exception cref="ArgumentNullException">The <paramref name="assetName"/> parameter is null or an empty string.</exception>
    /// <exception cref="ObjectDisposedException">This was called after the ContentManger was disposed.</exception>
    void UnloadAsset(string assetName);

    /// <summary>
    /// Unloads a set of assets loaded by this ContentManager where each element in the provided collection
    /// represents the name of an asset to unload.
    /// </summary>
    /// <remarks>
    /// If the asset being unloaded implements the <see cref="IDisposable"/> interface, then the
    /// <see cref="IDisposable.Dispose">IDisposable.Dispose </see > method will be called before unloading.
    /// </remarks>
    /// <param name="assetNames">The collection containing the names of assets to unload.</param>
    /// <exception cref="ArgumentNullException">
    /// If the <paramref name="assetNames"/> parameter is null.
    ///
    /// -or-
    ///
    /// If an element in the collection null or an empty string.
    /// </exception>
    /// <exception cref="ObjectDisposedException">This was called after the ContentManger was disposed.</exception>
    void UnloadAssets(IList<string> assetNames);
}
