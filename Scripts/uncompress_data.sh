## Uncompress_Data.sh
#   - Shell script to prepare the tar/gzipped data folders for the tests
#
# Author: Peter Rokowski (prokow01@villanova.edu)


PROJ_ROOT="..";
TARGET_DIR="$PROJ_ROOT/HyperSharp/MNIST";
DATA_PATH="$PROJ_ROOT/Data/";

DATA_NAME="mnist_data";
DATA_TAR="$DATA_NAME.tgz";
#if [ -z "$DATA_TAR" ]; then
#    echo "bad param: DATA_TAR - not provided or null";
#    exit 1;
#fi

echo "creating data_dir $TARGET_DIR";
mkdir -p $TARGET_DIR;

# make more complicated at some point
cd $DATA_PATH;
tar -xvf $DATA_TAR;

mv $DATA_NAME/* $TARGET_DIR/.;
rm -rf $DATA_NAME;

