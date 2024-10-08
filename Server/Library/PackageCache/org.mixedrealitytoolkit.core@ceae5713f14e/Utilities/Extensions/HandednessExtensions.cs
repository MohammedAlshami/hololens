﻿// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using UnityEngine.XR;

namespace MixedReality.Toolkit
{
    /// <summary>
    /// Extension methods that make working with the <see cref="Handedness"/> enum easier.
    /// </summary>
    public static class HandednessExtensions
    {
        /// <summary>
        /// Gets the opposite "hand" flag for the current <see cref="Handedness"/> value.
        /// </summary>
        /// <remarks>
        /// If Left, returns Right, if Right, returns Left otherwise returns None.
        /// Otherwise, returns None
        /// </remarks>
        public static Handedness GetOppositeHandedness(this Handedness current)
        {
            if (current == Handedness.Left)
            {
                return Handedness.Right;
            }
            else if (current == Handedness.Right)
            {
                return Handedness.Left;
            }
            else
            {
                return Handedness.None;
            }
        }

        /// <summary>
        /// Checks whether or not the current <see cref="Handedness"/> value matches the specified value.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="Handedness"/> value matches the current, otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsMatch(this Handedness current, Handedness compare)
        {
            return (current & compare) != 0;
        }

        /// <summary>
        /// Gets the <see cref="XRNode"/> representing the specified handedness. If the Handedness
        /// flags include both Left and Right, returns <see langword="null"/>.
        /// </summary>
        /// <param name="hand">The <see cref="Handedness"/> value for
        /// which the <see cref="XRNode"/> is requested.</param>
        /// <returns>
        /// <see cref="XRNode"/> representing the specified <see cref="Handedness"/>, or <see langword="null"/>.
        /// </returns>
        public static XRNode? ToXRNode(this Handedness hand)
        {
            if (hand == Handedness.Left) { return XRNode.LeftHand; }
            if (hand == Handedness.Right) { return XRNode.RightHand; }
            return null;
        }
    }
}
