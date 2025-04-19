using System;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics;

public interface ISpriteBatch : IDisposable
{
    /// <summary>
    /// Begins a new sprite and text batch with the specified render state.
    /// </summary>
    /// <param name="sortMode">The drawing order for sprite and text drawing. <see cref="SpriteSortMode.Deferred"/> by default.</param>
    /// <param name="blendState">State of the blending. Uses <see cref="BlendState.AlphaBlend"/> if null.</param>
    /// <param name="samplerState">State of the sampler. Uses <see cref="SamplerState.LinearClamp"/> if null.</param>
    /// <param name="depthStencilState">State of the depth-stencil buffer. Uses <see cref="DepthStencilState.None"/> if null.</param>
    /// <param name="rasterizerState">State of the rasterization. Uses <see cref="RasterizerState.CullCounterClockwise"/> if null.</param>
    /// <param name="effect">A custom <see cref="Effect"/> to override the default sprite effect. Uses default sprite effect if null.</param>
    /// <param name="transformMatrix">An optional matrix used to transform the sprite geometry. Uses <see cref="Matrix.Identity"/> if null.</param>
    /// <exception cref="InvalidOperationException">Thrown if <see cref="Begin"/> is called next time without previous <see cref="End"/>.</exception>
    /// <remarks>This method uses optional parameters.</remarks>
    /// <remarks>The <see cref="Begin"/> Begin should be called before drawing commands, and you cannot call it again before subsequent <see cref="End"/>.</remarks>
    void Begin
    (
        SpriteSortMode sortMode = SpriteSortMode.Deferred,
        BlendState blendState = null,
        SamplerState samplerState = null,
        DepthStencilState depthStencilState = null,
        RasterizerState rasterizerState = null,
        Effect effect = null,
        Matrix? transformMatrix = null
    );

    /// <summary>
    /// Flushes all batched text and sprites to the screen.
    /// </summary>
    /// <remarks>This command should be called after <see cref="Begin"/> and drawing commands.</remarks>
    void End ();

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this sprite.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this sprite.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this sprite.</param>
    void Draw (Texture2D texture,
        Vector2 position,
        Rectangle? sourceRectangle,
        Color color,
        float rotation,
        Vector2 origin,
        Vector2 scale,
        SpriteEffects effects,
        float layerDepth);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this sprite.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this sprite.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this sprite.</param>
    void Draw (Texture2D texture,
        Vector2 position,
        Rectangle? sourceRectangle,
        Color color,
        float rotation,
        Vector2 origin,
        float scale,
        SpriteEffects effects,
        float layerDepth);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this sprite.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this sprite.</param>
    void Draw (Texture2D texture,
        Rectangle destinationRectangle,
        Rectangle? sourceRectangle,
        Color color,
        float rotation,
        Vector2 origin,
        SpriteEffects effects,
        float layerDepth);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this sprite.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this sprite.</param>
    void Draw(Texture2D texture,
        RectangleF destinationRectangle,
        Rectangle? sourceRectangle,
        Color color,
        float rotation,
        Vector2 origin,
        SpriteEffects effects,
        float layerDepth);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    void Draw (Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    void Draw (Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full texture.</param>
    /// <param name="color">A color mask.</param>
    void Draw (Texture2D texture, RectangleF destinationRectangle, Rectangle? sourceRectangle, Color color);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    void Draw (Texture2D texture, Vector2 position, Color color);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="color">A color mask.</param>
    void Draw(Texture2D texture, Rectangle destinationRectangle, Color color);

    /// <summary>
    /// Submit a sprite for drawing in the current batch.
    /// </summary>
    /// <param name="texture">A texture.</param>
    /// <param name="destinationRectangle">The drawing bounds on screen.</param>
    /// <param name="color">A color mask.</param>
    void Draw(Texture2D texture, RectangleF destinationRectangle, Color color);

    /// <summary>
    /// Fills a specified rectangular area with a given color.
    /// </summary>
    /// <param name="destinationRectangle">Defines the area on the screen that will be filled with color.</param>
    /// <param name="color">Specifies the color used to fill the defined rectangular area.</param>
    void FillRectangle(Rectangle destinationRectangle, Color color);

    /// <summary>
    /// Fills a rectangular area with a specified color at a given position and size.
    /// </summary>
    /// <param name="position">Specifies the top-left corner of the rectangle to be filled.</param>
    /// <param name="width">Defines the horizontal size of the rectangle.</param>
    /// <param name="height">Defines the vertical size of the rectangle.</param>
    /// <param name="color">Indicates the color used to fill the rectangle.</param>
    void FillRectangle(Point position, int width, int height, Color color);

    /// <summary>
    /// Fills a rectangular area with a specified color at a given position and size.
    /// </summary>
    /// <param name="x">Specifies the left corner of the rectangle to be filled.</param>
    /// <param name="y">Specifies the top of the rectangle to be filled.</param>
    /// <param name="width">Defines the horizontal size of the rectangle.</param>
    /// <param name="height">Defines the vertical size of the rectangle.</param>
    /// <param name="color">Indicates the color used to fill the rectangle.</param>
    void FillRectangle(int x, int y, int width, int height, Color color);

    /// <summary>
    /// Fills a rectangular area with a specified color at a given position and size.
    /// </summary>
    /// <param name="x">Specifies the left corner of the rectangle to be filled.</param>
    /// <param name="y">Specifies the top of the rectangle to be filled.</param>
    /// <param name="width">Defines the horizontal size of the rectangle.</param>
    /// <param name="height">Defines the vertical size of the rectangle.</param>
    /// <param name="color">Indicates the color used to fill the rectangle.</param>
    void FillRectangle(float x, float y, float width, float height, Color color);

    /// <summary>
    /// Fills a specified rectangular area with a given color.
    /// </summary>
    /// <param name="destinationRectangle">Defines the area that will be filled with color.</param>
    /// <param name="color">Specifies the color used to fill the defined area.</param>
    void FillRectangle(RectangleF destinationRectangle, Color color);

    /// <summary>
    /// Fills a rectangular area with a specified color at a given position and size.
    /// </summary>
    /// <param name="position">Defines the top-left corner of the rectangle to be filled.</param>
    /// <param name="width">Specifies the horizontal size of the rectangle.</param>
    /// <param name="height">Specifies the vertical size of the rectangle.</param>
    /// <param name="color">Determines the color used to fill the rectangle.</param>
    void FillRectangle(Vector2 position, float width, float height, Color color);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    void DrawString (SpriteFont spriteFont, string text, Vector2 position, Color color);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    void DrawString (
        SpriteFont spriteFont, string text, Vector2 position, Color color,
        float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    void DrawString (
        SpriteFont spriteFont, string text, Vector2 position, Color color,
        float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    /// <param name="rtl">Text is Right to Left.</param>
    void DrawString(
        SpriteFont spriteFont, string text, Vector2 position, Color color,
        float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, bool rtl);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    void DrawString (SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    void DrawString (
        SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color,
        float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    void DrawString (
        SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color,
        float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);

    /// <summary>
    /// Submit a text string of sprites for drawing in the current batch.
    /// </summary>
    /// <param name="spriteFont">A font.</param>
    /// <param name="text">The text which will be drawn.</param>
    /// <param name="position">The drawing location on screen.</param>
    /// <param name="color">A color mask.</param>
    /// <param name="rotation">A rotation of this string.</param>
    /// <param name="origin">Center of the rotation. 0,0 by default.</param>
    /// <param name="scale">A scaling of this string.</param>
    /// <param name="effects">Modificators for drawing. Can be combined.</param>
    /// <param name="layerDepth">A depth of the layer of this string.</param>
    /// <param name="rtl">Text is Right to Left.</param>
    void DrawString(
        SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color,
        float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, bool rtl);

    /// <summary>
    /// Gets the <see cref="Graphics.GraphicsDevice"/> associated with this <see cref="GraphicsResource"/>.
    /// </summary>
    GraphicsDevice GraphicsDevice { get; }
}
