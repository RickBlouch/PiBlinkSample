﻿using System.Drawing;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Image;

namespace ImageDetectionYoloV4.YoloV4
{
    public class YoloV4Result
    {
        /// <summary>
        /// x1, y1, x2, y2 in page coordinates.
        /// <para>left, top, right, bottom.</para>
        /// </summary>
        public float[] BBox { get; }

        /// <summary>
        /// The Bbox category.
        /// </summary>
        public string Label { get; }

        /// <summary>
        /// Confidence level.
        /// </summary>
        public float Confidence { get; }

        public YoloV4Result(float[] bbox, string label, float confidence)
        {
            BBox = bbox;
            Label = label;
            Confidence = confidence;
        }
    }
}
