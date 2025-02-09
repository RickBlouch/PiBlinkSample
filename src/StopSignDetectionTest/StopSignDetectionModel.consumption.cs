﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace StopSignDetectionTest
{
    public partial class StopSignDetectionModel
    {
        /// <summary>
        /// model input class for StopSignDetectionModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"Label")]
            public string Label { get; set; }

            [ColumnName(@"ImageSource")]
            public string ImageSource { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for StopSignDetectionModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            public string[] ObjectTags = new string[] { "--bg--", "Stop-Sign", };

            [ColumnName("boxes")]
            public float[] Boxes { get; set; } = new float[0];

            [ColumnName("labels")]
            public long[] Labels { get; set; } = new long[0];

            [ColumnName("scores")]
            public float[] Scores { get; set; } = new float[0];

            public BoundingBox[] BoundingBoxes
            {
                get
                {
                    var boundingBoxes = Enumerable.Range(0, this.Labels.Length)
                              .Select((index) =>
                              {
                                  var boxes = this.Boxes;
                                  var scores = this.Scores;
                                  var labels = this.Labels;

                                  return new BoundingBox()
                                  {
                                      Left = boxes[index * 4],
                                      Top = boxes[(index * 4) + 1],
                                      Right = boxes[(index * 4) + 2],
                                      Bottom = boxes[(index * 4) + 3],
                                      Score = scores[index],
                                      Label = this.ObjectTags[labels[index]],
                                  };
                              }).ToArray();
                    return boundingBoxes;
                }
            }

            public override string ToString()
            {
                return string.Join("\n", this.BoundingBoxes.Select(x => x.ToString()));
            }

            public class BoundingBox
            {
                public float Top;

                public float Left;

                public float Right;

                public float Bottom;

                public string Label;

                public float Score;

                public override string ToString()
                {
                    return $"Top: {this.Top}, Left: {this.Left}, Right: {this.Right}, Bottom: {this.Bottom}, Label: {this.Label}, Score: {this.Score}";
                }
            }
        }


        #endregion

        private static string MLNetModelPath = Path.GetFullPath("StopSignDetectionModel.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
